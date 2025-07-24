import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetOrCreatePFileComponent } from './get-or-create-pfile.component';

describe('GetOrCreatePFileComponent', () => {
  let component: GetOrCreatePFileComponent;
  let fixture: ComponentFixture<GetOrCreatePFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetOrCreatePFileComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetOrCreatePFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
