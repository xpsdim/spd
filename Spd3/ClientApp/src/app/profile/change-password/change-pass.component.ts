import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../../shared/services/profile.service';

@Component({
  selector: 'change-pass',
  templateUrl: './change-pass.component.html',
  styleUrls: ['./change-pass.component.css']
})
export class ChangePasswordFormComponent implements OnInit {

  constructor(private profileService: ProfileService) { }

  ngOnInit() {
    this.profileService.getChangePasswordData()
      .subscribe(
      function (response) {
        console.log(response);
      }
      )
  }

}
