import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { TodoDetailsFormComponent } from "./todo-details-form/todo-details-form.component";
import { TodoDetailsService } from '../shared/todo-details.service';
import { TodoDetails } from '../shared/todo-details.model';


@Component({
  selector: 'app-todo-details',
  standalone: true,
  imports: [RouterOutlet, CommonModule, TodoDetailsFormComponent],
  templateUrl: './todo-details.component.html',
  styleUrl: './todo-details.component.css'
})
export class TodoDetailsComponent implements OnInit {
  constructor(public service: TodoDetailsService){
    
  }
  ngOnInit(): void {
    this.service.refreshTodoList();
  }

  populateForm(selectedRecord:TodoDetails) {

    this.service.formData =Object.assign({}, selectedRecord);

  }

  onDelete(id:number){
    if (confirm("You are trying to Delete This Todo, make sure that you have completed the task you created."))
    this.service.deleteTodoDetals(id)
    .subscribe({
      next: res => {
        this.service.list = res as TodoDetails[]
      },
      error: err => {
        console.log(err)
      }
    })
  }

}
