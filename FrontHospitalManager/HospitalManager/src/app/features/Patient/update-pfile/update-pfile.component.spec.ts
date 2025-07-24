import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePfileComponent } from './update-pfile.component';

describe('UpdatePfileComponent', () => {
  let component: UpdatePfileComponent;
  let fixture: ComponentFixture<UpdatePfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdatePfileComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdatePfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
