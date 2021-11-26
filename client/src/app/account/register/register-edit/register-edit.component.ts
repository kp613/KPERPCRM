import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AngularFileUploaderComponent } from 'angular-file-uploader';
import { ToastrService } from 'ngx-toastr';
import { Observable, ReplaySubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { AccountService } from '../../account.service';
import { ILoggedUser } from '../../loggedUser';
import { IMember } from '../../members/member';
import { MembersService } from '../../members/members.service';

@Component({
  selector: 'app-register-edit',
  templateUrl: './register-edit.component.html',
  styleUrls: ['./register-edit.component.scss']
})
export class RegisterEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;

  member: IMember;
  user: ILoggedUser;

  username: string;
  profilePicture: string = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAACXBIWXMAAAsTAAALEwEAmpwYAAAFwmlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDIgNzkuMTYwOTI0LCAyMDE3LzA3LzEzLTAxOjA2OjM5ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdEV2dD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlRXZlbnQjIiB4bWxuczpkYz0iaHR0cDovL3B1cmwub3JnL2RjL2VsZW1lbnRzLzEuMS8iIHhtbG5zOnBob3Rvc2hvcD0iaHR0cDovL25zLmFkb2JlLmNvbS9waG90b3Nob3AvMS4wLyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ0MgKFdpbmRvd3MpIiB4bXA6Q3JlYXRlRGF0ZT0iMjAyMS0wOC0yMlQxMTozODo0NyswODowMCIgeG1wOk1ldGFkYXRhRGF0ZT0iMjAyMS0wOC0yMlQxMTozODo0NyswODowMCIgeG1wOk1vZGlmeURhdGU9IjIwMjEtMDgtMjJUMTE6Mzg6NDcrMDg6MDAiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6NmVmYWQzNjgtM2EyOC1jOTQ4LTgzZDgtMWU4MDYyYTAzZGE4IiB4bXBNTTpEb2N1bWVudElEPSJhZG9iZTpkb2NpZDpwaG90b3Nob3A6YjE1ZmVkNDEtNGFiNi1kNjRjLTk0ODYtZTY0ZWE5YWUwZWQ4IiB4bXBNTTpPcmlnaW5hbERvY3VtZW50SUQ9InhtcC5kaWQ6OWQ2MTI4NjctYWZmZS0xMjQzLWJhNWItNzk4NWJkYmVkMDE1IiBkYzpmb3JtYXQ9ImltYWdlL3BuZyIgcGhvdG9zaG9wOkNvbG9yTW9kZT0iMyI+IDx4bXBNTTpIaXN0b3J5PiA8cmRmOlNlcT4gPHJkZjpsaSBzdEV2dDphY3Rpb249ImNyZWF0ZWQiIHN0RXZ0Omluc3RhbmNlSUQ9InhtcC5paWQ6OWQ2MTI4NjctYWZmZS0xMjQzLWJhNWItNzk4NWJkYmVkMDE1IiBzdEV2dDp3aGVuPSIyMDIxLTA4LTIyVDExOjM4OjQ3KzA4OjAwIiBzdEV2dDpzb2Z0d2FyZUFnZW50PSJBZG9iZSBQaG90b3Nob3AgQ0MgKFdpbmRvd3MpIi8+IDxyZGY6bGkgc3RFdnQ6YWN0aW9uPSJzYXZlZCIgc3RFdnQ6aW5zdGFuY2VJRD0ieG1wLmlpZDo2ZWZhZDM2OC0zYTI4LWM5NDgtODNkOC0xZTgwNjJhMDNkYTgiIHN0RXZ0OndoZW49IjIwMjEtMDgtMjJUMTE6Mzg6NDcrMDg6MDAiIHN0RXZ0OnNvZnR3YXJlQWdlbnQ9IkFkb2JlIFBob3Rvc2hvcCBDQyAoV2luZG93cykiIHN0RXZ0OmNoYW5nZWQ9Ii8iLz4gPC9yZGY6U2VxPiA8L3htcE1NOkhpc3Rvcnk+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+W4HAEgAAAA1JREFUCB1j+P//PwMACPwC/uYM/6sAAAAASUVORK5CYII=";
  //empty.png


  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private accountService: AccountService,
    private memberService: MembersService,
    private toastr: ToastrService
  ) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  // afuConfig = {
  //   uploadAPI: {
  //     url: "https://example-file-upload-api"
  //   }
  // };

  // afuConfig2 = {
  //   // multiple: false,
  //   formatsAllowed: ".jpg,.png",
  //   // maxSize: "1",
  //   uploadAPI: {
  //     url: "https://example-file-upload-api",
  //     method: "POST",
  //     // headers: {
  //     //   "Content-Type": "text/plain;charset=UTF-8",
  //     //   "Authorization": `Bearer ${token}`
  //     // },
  //     params: {
  //       'page': '1'
  //     },
  //     responseType: 'blob',
  //     withCredentials: false,
  //   },
  //   theme: "dragNDrop",
  //   hideProgressBar: true,
  //   hideResetBtn: true,
  //   hideSelectBtn: true,
  //   fileNameIndex: true,
  //   autoUpload: false,
  //   replaceTexts: {
  //     selectFileBtn: 'Select Files',
  //     resetBtn: 'Reset',
  //     uploadBtn: 'Upload',
  //     dragNDropBox: 'Drag N Drop',
  //     attachPinBtn: 'Attach Files...',
  //     afterUploadMsg_success: 'Successfully Uploaded !',
  //     afterUploadMsg_error: 'Upload Failed !',
  //     sizeLimit: 'Size Limit'
  //   }
  // };

  // @ViewChild('fileUpload3')
  // private fileUpload3: AngularFileUploaderComponent;
  // afuConfig3 = {
  //   uploadAPI: {
  //     url: "https://example-file-upload-api"
  //   }
  // };

  convertFile(file: File): Observable<string> {
    const result = new ReplaySubject<string>(1);
    const reader = new FileReader();
    reader.readAsBinaryString(file);
    reader.onload = (event) => result.next(btoa(event.target.result.toString()));
    return result;
  }

  onFileSelected(event) {
    this.convertFile(event.target.files[0]).subscribe(base64 => {
      this.profilePicture = base64;
    });
  }

  uploadImg(username, profilePicture) {
    this.memberService.uploadImage(username, profilePicture).subscribe((res) => {
      profilePicture = this.profilePicture;
      this.loadMember();
      this.toastr.success('图片上传成功');
    }, (error) => {
      this.toastr.error(error.error);
    })
  }

  ngOnInit(): void {
    this.loadMember();

    // this.fileUpload3.resetFileUpload();
  }

  loadMember() {
    this.memberService.getMember(this.user.username).subscribe(member => {
      this.member = member;
    })
  }

  updateMember() {
    this.memberService.updateMember(this.member).subscribe(() => {
      this.toastr.success('保存成功！Profile updated successfully');
      this.editForm.reset(this.member);
    })
  }

}
