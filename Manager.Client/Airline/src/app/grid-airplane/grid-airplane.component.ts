import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Airplane } from '../models/airplane.model';

@Component({
  selector: 'app-grid-airplane',
  templateUrl: './grid-airplane.component.html',
  styleUrls: ['./grid-airplane.component.css']
})
export class GridAirplaneComponent implements OnInit {

  @Output() recordDeleted = new EventEmitter<any>();
  @Output() newClicked = new EventEmitter<any>();
  @Output() editClicked = new EventEmitter<any>();
  @Input() airplaneData: Array<Airplane>;

  constructor() { }

  ngOnInit() {
  }

  public deleteRecord(record){
    this.recordDeleted.emit(record);
  }

  public editRecord(record){
    const clonedRecord = Object.assign({}, record);
    this.editClicked.emit(clonedRecord);
  }

  public newRecord(){
    this.newClicked.emit();
  }

}
