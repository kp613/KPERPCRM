import { ChangeDetectionStrategy, Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MessageService } from 'src/app/admin/message/message.service';
import { IMessage } from '../message';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-member-messages',
  templateUrl: './member-messages.component.html',
  styleUrls: ['./member-messages.component.scss']
})
export class MemberMessagesComponent implements OnInit {
  @ViewChild('messageForm') messageForm: NgForm;
  @Input() messages: IMessage[];
  @Input() username: string;
  messageContent: string;
  // loading = false;


  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
  }


  sendMessage() {
    this.messageService.sendMessage(this.username, this.messageContent).subscribe(message => {
      this.messages.push(message);
      this.messageForm.reset();
    })
    // this.loading = true;
    // this.messageService.sendMessage(this.username, this.messageContent).then(() => {
    //   this.messageForm.reset();
    // }).finally(() => this.loading = false);
  }

}
