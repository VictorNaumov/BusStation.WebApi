import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

export type NotificationType = 'text' | 'error';

export interface Notification {
    type: NotificationType,
    text: string,
}

@Injectable({ providedIn: 'root' })
export class NotificationService {
    public notification$ = new Subject<Notification>();

    textNotice(text: string) {
        this.notification$.next({ type: 'text', text })
    }

    ErrorNotice(text: string) {
        this.notification$.next({ type: 'error', text })
    }
}
