import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TodoDetailsComponent } from "./todo-details/todo-details.component";
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, TodoDetailsComponent ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'TodosApp';
}
