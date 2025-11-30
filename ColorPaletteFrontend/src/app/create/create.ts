import { Component } from '@angular/core';
import { ColorService } from '../services/color';
import { ColorCreateDto } from '../models/color-create-dto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  standalone: false,
  templateUrl: './create.html',
  styleUrl: './create.sass',
})
export class Create {
  newColor: ColorCreateDto = new ColorCreateDto()

  constructor(public service: ColorService, private router: Router) {}

  create() {
    this.service.createColor(this.newColor).subscribe(c => {
      this.newColor = new ColorCreateDto()
      this.router.navigate(['list'])
    })
  }

  /*removeChar() {
    this.newColor.colorHex = this.newColor.colorHex.replace('#', '')
  }*/
}
