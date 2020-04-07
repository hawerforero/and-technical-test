import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ActivoEditComponent } from './activo-edit.component';

let component: ActivoEditComponent;
let fixture: ComponentFixture<ActivoEditComponent>;

describe('activo-edit component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ActivoEditComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ActivoEditComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
