import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busyRequestCount = 0;


  constructor(private spinnerService: NgxSpinnerService) { }

  busy() {
    this.busyRequestCount++;
    this.spinnerService.show(undefined, {
      type: 'line-scale-pulse-out-rapid',
      //ball-scale-multiple,line-scale-party,ball-spin-fade,ball-spin-clockwise-fade,pacman,ball-newton-cradle,
      //ball-elastic-dots,ball-clip-rotate-multiple,ball-pulse-sync,ball-scale-multiple,ball-spin-clockwise,line-scale-pulse-out-rapid
      bdColor: 'rgba(255,255,255,0)',
      color: 'gray'
    });
  }

  idle() {
    this.busyRequestCount--;
    if (this.busyRequestCount <= 0) {
      this.busyRequestCount = 0;
      this.spinnerService.hide();
    }
  }

}
