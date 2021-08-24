using Stateless;
using System;
using System.Collections.Generic;

namespace API.Models.BusinessModels.OrderSell
{
    public enum OrderStatus
    {
        Pending,        //订单已生成
        Processing,     //发货或收款中
        Completed,      //订单完成
        Cancelled,      //订单取消
        Declined,       //交易失败
        Refund,         //已退款
    }

    public enum OrderStatusTrigger
    {
        PlaceOrder,     //支付
        Approve,        //支付成功
        Reject,         //支付失败
        Cancel,         //取消
        Return          //退货
    }

    public class Order
    {
        public Order()
        {
            StateMachineInit();
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail,
            Address shipToAddress, DeliveryMethod deliveryMethod,
            decimal subtotal, string paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
            PaymentIntentId = paymentIntentId;
        }

        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }

        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }

        StateMachine<OrderStatus, OrderStatusTrigger> _machine;
        private void StateMachineInit()
        {
            _machine = new StateMachine<OrderStatus, OrderStatusTrigger>(OrderStatus.Pending);  //初始化状态机
            _machine.Configure(OrderStatus.Pending)
                .Permit(OrderStatusTrigger.PlaceOrder, OrderStatus.Processing)
                .Permit(OrderStatusTrigger.Cancel, OrderStatus.Cancelled);

            _machine.Configure(OrderStatus.Processing)
                .Permit(OrderStatusTrigger.Approve, OrderStatus.Completed)
                .Permit(OrderStatusTrigger.Reject, OrderStatus.Declined);

            _machine.Configure(OrderStatus.Declined)
               .Permit(OrderStatusTrigger.PlaceOrder, OrderStatus.Processing);

            _machine.Configure(OrderStatus.Completed)
               .Permit(OrderStatusTrigger.Return, OrderStatus.Refund);
        }
    }
}