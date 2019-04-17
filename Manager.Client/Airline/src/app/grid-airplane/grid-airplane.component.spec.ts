import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridAirplaneComponent } from './grid-airplane.component';

describe('GridAirplaneComponent', () => {
  let component: GridAirplaneComponent;
  let fixture: ComponentFixture<GridAirplaneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridAirplaneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridAirplaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
