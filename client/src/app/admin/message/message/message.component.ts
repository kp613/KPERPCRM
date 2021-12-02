import { Component, OnInit } from '@angular/core';
import { IPagination } from 'src/app/_core/models/pagination';
import { ConfirmService } from 'src/app/_core/services/confirm.service';
import { MessageService } from 'src/app/admin/message/message.service';
import { IMessage } from '../message';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss']
})
export class MessageComponent implements OnInit {
  messages: IMessage[] = [];
  pagination: IPagination;
  container = 'Unread';
  pageNumber = 1;
  pageSize = 5;
  loading = false;

  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
    this.loadMessages();
  }

  loadMessages() {
    this.loading = true;
    this.messageService.getMessages(this.pageNumber, this.pageSize, this.container).subscribe(response => {
      this.messages = response.result;
      this.pagination = response.pagination;
      this.loading = false;
    })
  }

  deleteMessage(id: number) {
    this.messageService.deleteMessage(id).subscribe(() => {
      this.messages.splice(this.messages.findIndex(m => m.id === id), 1);
    })

    // this.confirmService.confirm('Confirm delete message', 'This cannot be undone').subscribe(result => {
    //   if (result) {
    //     this.messageService.deleteMessage(id).subscribe(() => {
    //       this.messages.splice(this.messages.findIndex(m => m.id === id), 1);
    //     })
    //   }
    // })

  }

  pageChanged(event: any) {
    this.pageNumber = event.page;
    this.loadMessages();
  }

}

