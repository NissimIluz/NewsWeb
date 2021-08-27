import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pre-review',
  templateUrl: './pre-review.component.html',
  styleUrls: ['./pre-review.component.css']
})
export class PreReviewComponent implements OnInit {
  @Input() index:number | undefined
  @Input() title : string =""
  @Input() updated : string = ""
  @Output() setSelectedIndex = new EventEmitter<any>()

  constructor() { }

  ngOnInit(): void {
  }
  Select() {
    window.scroll(0,135)
    this.setSelectedIndex.emit(this.index)
  }
}
