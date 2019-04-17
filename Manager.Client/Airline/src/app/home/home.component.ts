import { Component, OnInit } from '@angular/core';
import { BaseService } from '../base.service';
import * as _ from 'lodash';

const url: string = 'airplane';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public airplaneData: Array<any>;
  public currentAirplane: any;

  constructor(private baseService: BaseService) {
    baseService.get(url).subscribe((data: any) => this.airplaneData = data);
    this.currentAirplane = this.setInitialAirplaneValues();
  }

  ngOnInit() {
  }

  private setInitialAirplaneValues() {
    return {
      id: undefined,
      code: '',
      model: '',
      passengersQtt: 0,
      createDate: ''
    }
  }

  public manageAirplane = function (airplane: any) {
    let airplaneExisting;
    airplaneExisting = _.find(this.airplaneData, (el => el.id === airplane.id));

    if (airplaneExisting) {
      //updating
      const updateIndex = _.findIndex(this.airplaneData, { id: airplaneExisting.id });
      this.baseService.put(url, airplane).subscribe(
        (result: any) => this.airplanedata.splice(updateIndex, 1, airplane)
      );
    }
    else {
      //creating new
      this.baseService.post(url, airplane).subscribe(
        (result: any) => this.airplanedata.push(airplane)
      )
    }

    this.currentAirplane = this.setInitialAirplaneValues();
  }

  public editClicked = function (record) {
    this.currentAirplane = record;
  }

  public newClicked = function () {
    this.currentAirplane = this.setInitialAirplaneValues();
  }

  public deleteClicked(record) {
    const deleteIndex = _.findIndex(this.airplaneData, { id: record.id });
    this.baseService.delete(url, record).subscribe(
      result => this.airplaneData.splice(deleteIndex, 1)
    )
  }

}
