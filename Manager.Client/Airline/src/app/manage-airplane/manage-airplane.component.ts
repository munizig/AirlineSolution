import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'app-manage-airplane',
  templateUrl: './manage-airplane.component.html',
  styleUrls: ['./manage-airplane.component.css']
})
export class ManageAirplaneComponent implements OnInit {

  @Output() airplaneCreated = new EventEmitter<any>();
  @Input() airplaneInfo: any;

  public buttonText = 'Save';

  constructor() {
    this.clearAirplaneInfo();
    console.log(this.airplaneInfo);
  }

  ngOnInit() {
  }

  private clearAirplaneInfo = function () {
    this.airplaneInfo = {
      id: undefined,
      code: '',
      model: '',
      passengersQtt: 0,
      createDate: ''
    };
  }

  public manageAirplaneRecord = function (event) {
    this.airplaneCreated.emit(this.airplaneInfo);
    this.clearAirplaneInfo();
  }

}
