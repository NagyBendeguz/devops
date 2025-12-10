import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Color } from '../models/color';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { ColorCreateDto } from '../models/color-create-dto';

@Injectable({
  providedIn: 'root',
})
export class ColorService {
  colors: Observable<Color[]> = new Observable<Color[]>

  constructor(private http: HttpClient) {
    this.getColors();
  }
  
  getColors() {
    this.colors = this.http.get<Color[]>(environment.backendUrl + "/api/Color")
  }

  createColor(color: ColorCreateDto) {
    return this.http.post<Color>(environment.backendUrl + "/api/Color", color).pipe(
      tap(c => {
        this.getColors()
      })
    )
  }
}
