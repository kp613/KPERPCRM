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
  profilePicture: string;



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
