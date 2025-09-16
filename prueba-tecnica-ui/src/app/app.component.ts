import { Component } from '@angular/core';
import { ClientesComponent } from './features/clientes/clientes/clientes.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ClientesComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {}