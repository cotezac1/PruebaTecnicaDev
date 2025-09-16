import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../clientes.service';
import { Cliente } from '../../../models/cliente.model';
import { PhoneFormatPipe } from '../../../pipes/phone-format.pipe';

@Component({
  selector: 'app-clientes',
  standalone: true,
  imports: [PhoneFormatPipe],
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss']
})
export class ClientesComponent implements OnInit {

  clientes: Cliente[] = [];
  loading = false;
  error: string | null = null;

  constructor(private clientesService: ClientesService) { }

  ngOnInit(): void {
    this.loadClientes();
  }

  private loadClientes(): void {
    this.loading = true;
    this.error = null;


    this.clientesService.getClientesLinq(1, 10).subscribe({
      next: (response: any) => {
        this.clientes = response.items; 
        this.loading = false;
      },
      error: (err: any) => {
        this.error = 'Error al cargar los clientes';
        this.loading = false;
        console.error('Error:', err);
      }
    });
  }
}
