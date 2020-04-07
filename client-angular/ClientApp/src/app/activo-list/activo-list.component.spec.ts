/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ActivoListComponent } from './activo-list.component';

let component: ActivoListComponent;
let fixture: ComponentFixture<ActivoListComponent>;

describe('activo-list component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ActivoListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ActivoListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});