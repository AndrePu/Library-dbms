import { OperationStatus } from './operation-status.model';

export class OperationResult<T> {
    status: OperationStatus;
    message: string;
    result: T;
}
