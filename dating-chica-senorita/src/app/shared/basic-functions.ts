import { Subject } from "rxjs";

export function autoDestroy(vars: Subject<void>[]): void {
    vars.forEach((v) => {
      v.next();
      v.complete();
    });
}