import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfigService } from '../shared/utils/config.service';
import { ProfileService } from '../shared/services/profile.service';


@NgModule({
  imports: [CommonModule],
  providers: [ProfileService, ConfigService]
})
export class ProfileModule { }
