import { Component } from '@angular/core';
import { TodoDetailsService } from '../../shared/todo-details.service';
import { FormsModule, NgForm } from '@angular/forms';
import { TodoDetails } from '../../shared/todo-details.model';


@Component({
  selector: 'app-todo-details-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './todo-details-form.component.html',
  styleUrl: './todo-details-form.component.css'
})
export class TodoDetailsFormComponent {
  constructor(public service: TodoDetailsService) {
  }

  onSubmit(form: NgForm) {
    this.service.formSubmited = true
    if (form.valid) {
      if(this.service.formData.todoId == 0 )
        this.insertRecord(form)
      else
        this.updateRecord(form)
    }

  }

  insertRecord(form: NgForm) {
    this.service.postTodoDetals()
    .subscribe({
      next: res => {
        this.service.list = res as TodoDetails[]
        this.service.resetForm(form)

      },
      error: err => {
        console.log(err)
      }
    })
  }
  updateRecord(form: NgForm) { 
    this.service.putTodoDetals()
    .subscribe({
      next: res => {
        this.service.list = res as TodoDetails[]
        this.service.resetForm(form)
      },
      error: err => {
        console.log(err)
      }
    })
  }


}
