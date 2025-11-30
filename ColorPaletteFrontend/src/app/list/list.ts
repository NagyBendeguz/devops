import { Component } from '@angular/core';
import { ColorService } from '../services/color';

@Component({
  selector: 'app-list',
  standalone: false,
  templateUrl: './list.html',
  styleUrl: './list.sass',
})
export class List {
  constructor(public service: ColorService) {}
}
