import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Airplane } from '../models/airplane.model';

@Component({
  selector: 'app-manage-airplane',
  templateUrl: './manage-airplane.component.html',
  styleUrls: ['./manage-airplane.component.css']
})
export class ManageAirplaneComponent implements OnInit {

  @Output() airplaneCreated = new EventEmitter<any>();
  @Input() airplaneInfo: Airplane;

  public buttonText = 'Save';

  constructor() {
    this.clearAirplaneInfo();
    console.log(this.airplaneInfo);
  }

  ngOnInit() {
  }

  private clearAirplaneInfo = function () {
    this.airplaneInfo = new Airplane(undefined, '', '', 0, '');
  }

  public manageAirplaneRecord = function (event) {
    this.airplaneCreated.emit(this.airplaneInfo);
    this.clearAirplaneInfo();
  }

}
