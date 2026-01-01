import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PatientSignup } from "./auth/patient-signup/patient-signup";

@Component({
  selector: 'app-root',
  imports: [PatientSignup],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
}
