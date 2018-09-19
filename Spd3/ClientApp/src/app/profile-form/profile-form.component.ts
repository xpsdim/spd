import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import { ChangePassword } from '../shared/models/change.password';
import { ProfileService } from '../shared/services/profile.service';

@Component({
  selector: 'app-profile-form',
  templateUrl: './profile-form.component.html',
  styleUrls: ['./profile-form.component.css']
})
export class ProfileFormComponent implements OnInit {

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
