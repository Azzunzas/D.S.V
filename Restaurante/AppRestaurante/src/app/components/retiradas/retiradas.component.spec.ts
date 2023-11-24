import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetiradasComponent } from './retiradas.component';

describe('RetiradasComponent', () => {
  let component: RetiradasComponent;
  let fixture: ComponentFixture<RetiradasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RetiradasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RetiradasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
