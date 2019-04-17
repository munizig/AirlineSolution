import { Component, OnInit } from '@angular/core';
import { BaseService } from '../base.service';
import * as _ from 'lodash';
import { Airplane } from '../models/airplane.model';

const url: string = 'airplanes';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public airplaneData: Array<any>;
  public currentAirplane: any;

  constructor(private baseService: BaseService) {
    console.log('before call get');
    const subscriber = baseService.get(url)
      .subscribe((data: any) => {
        console.log(data);
        this.airplaneData = data
        subscriber.unsubscribe();
      }, error => { 
        console.log('error');
      }
      );
    this.currentAirplane = this.setInitialAirplaneValues();
  }

  ngOnInit() {
  }

  private setInitialAirplaneValues() {
    return new Airplane(undefined, '', '', 0, '');
  }

  public manageAirplane = function (airplane: any) {
    let airplaneExisting: any;
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
