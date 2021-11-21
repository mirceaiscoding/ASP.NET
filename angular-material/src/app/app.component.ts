import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-material';
  isChecked = true;
  text = 0;
  onChange($event){
    console.log($event)
    this.text += 1;
  }
}
