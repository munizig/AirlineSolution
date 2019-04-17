import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageAirplaneComponent } from './manage-airplane.component';

describe('ManageAirplaneComponent', () => {
  let component: ManageAirplaneComponent;
  let fixture: ComponentFixture<ManageAirplaneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageAirplaneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageAirplaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
