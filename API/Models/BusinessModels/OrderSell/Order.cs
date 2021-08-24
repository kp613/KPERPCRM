using Stateless;
using System;
using System.Collections.Generic;

namespace API.Models.BusinessModels.OrderSell
{
    public enum OrderStatus
    {
        Pending,        //����������
        Processing,     //�������տ���
        Completed,      //�������
        Cancelled,      //����ȡ��
        Declined,       //����ʧ��
        Refund,         //���˿�
    }

    public enum OrderStatusTrigger
    {
        PlaceOrder,     //֧��
        Approve,        //֧���ɹ�
        Reject,         //֧��ʧ��
        Cancel,         //ȡ��
        Return          //�˻�
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
            _machine = new StateMachine<OrderStatus, OrderStatusTrigger>(OrderStatus.Pending);  //��ʼ��״̬��
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