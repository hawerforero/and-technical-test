import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ActivoCreateComponent } from './activo-create.component';

let component: ActivoCreateComponent;
let fixture: ComponentFixture<ActivoCreateComponent>;

describe('activo-create component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ActivoCreateComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ActivoCreateComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
