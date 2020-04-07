
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ActivoDetailsComponent } from './activo-details.component';

let component: ActivoDetailsComponent;
let fixture: ComponentFixture<ActivoDetailsComponent>;

describe('activo-details component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ActivoDetailsComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ActivoDetailsComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
