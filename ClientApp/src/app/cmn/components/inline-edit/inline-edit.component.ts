import { Component, Input, Optional, Host, OnInit } from '@angular/core';
import { SatPopover } from '@ncstate/sat-popover';

@Component({
  selector: 'app-inline-edit',
  templateUrl: './inline-edit.component.html',
  styleUrls: ['./inline-edit.component.scss']
})
export class InlineEditComponent implements OnInit {

  /** Overrides the comment and provides a reset value when changes are cancelled. */
  @Input() value = '';
  /** Form model for the input. */
  public comment = '';

  constructor(@Optional() @Host() public popover: SatPopover) { }

  public ngOnInit(): void {
    // subscribe to cancellations and reset form value
    if (this.popover) {
      this.comment = this.value;
    }
  }

  public onSubmit(): void {
    if (this.popover) {
      this.popover.close(this.comment);
    }
  }

  public onCancel(): void {
    if (this.popover) {
      this.popover.close();
    }
  }
}
