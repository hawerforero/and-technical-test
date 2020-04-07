
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { MovimientoListComponent } from './movimiento-list.component';

let component: MovimientoListComponent;
let fixture: ComponentFixture<MovimientoListComponent>;

describe('movimiento-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ MovimientoListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(MovimientoListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
