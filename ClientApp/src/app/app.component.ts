import { ToasterConfig } from 'angular2-toaster';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Client'; public defaultConfig = {
    showCloseButton: true,
    tapToDismiss: false,
    newestOnTop: true,
    mouseoverTimerStop: true,
    preventDuplicates: true,
    positionClass: 'toast-bottom-right',
    animation: 'flyRight',
    limit: 5,
    timeout: {
        error: 0,
        wait: 0,
        info: 4000,
        warning: 4000,
        success: 4000
    },
    toastContainerId: 1

};

public toasterconfig: ToasterConfig;

public ngOnInit(): void {
    this.toasterconfig = new ToasterConfig(Object.assign({}, this.defaultConfig));
}
}
