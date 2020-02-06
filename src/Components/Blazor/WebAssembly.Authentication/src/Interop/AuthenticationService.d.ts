import { UserManager, UserManagerSettings } from 'oidc-client';
export interface AccessTokenRequestOptions {
    scopes: string[];
    returnUrl: string;
}
export interface AccessTokenResult {
    status: AccessTokenResultStatus;
    token?: AccessToken;
}
export interface AccessToken {
    value: string;
    expires: Date;
    grantedScopes: string[];
}
export declare enum AccessTokenResultStatus {
    Success = "success",
    RequiresRedirect = "requiresRedirect"
}
export declare enum AuthenticationResultStatus {
    Redirect = "redirect",
    Success = "success",
    Failure = "failure",
    OperationCompleted = "operation-completed"
}
export interface AuthenticationResult {
    status: AuthenticationResultStatus;
    state?: any;
    message?: string;
}
export interface AuthorizeService {
    getUser(): Promise<any>;
    getAccessToken(request?: AccessTokenRequestOptions): Promise<AccessTokenResult>;
    signIn(state: any): Promise<AuthenticationResult>;
    completeSignIn(state: any): Promise<AuthenticationResult>;
    signOut(state: any): Promise<AuthenticationResult>;
    completeSignOut(url: string): Promise<AuthenticationResult>;
}
declare class OidcAuthorizeService implements AuthorizeService {
    private _userManager;
    constructor(userManager: UserManager);
    getUser(): Promise<import("oidc-client").Profile | null>;
    getAccessToken(request?: AccessTokenRequestOptions): Promise<AccessTokenResult>;
    signIn(state: any): Promise<{
        status: AuthenticationResultStatus;
    }>;
    completeSignIn(url: string): Promise<{
        status: AuthenticationResultStatus;
    }>;
    signOut(state: any): Promise<{
        status: AuthenticationResultStatus;
    }>;
    completeSignOut(url: string): Promise<{
        status: AuthenticationResultStatus;
    }>;
    private stateExists;
    private loginRequired;
    private createArguments;
    private error;
    private success;
    private redirect;
    private operationCompleted;
}
export declare class AuthenticationService {
    static _infrastructureKey: string;
    static _initialized: boolean;
    static instance: OidcAuthorizeService;
    static init(settings: UserManagerSettings & AuthorizeServiceSettings): Promise<void>;
    static getUser(): Promise<import("oidc-client").Profile | null>;
    static getAccessToken(): Promise<AccessTokenResult>;
    static signIn(state: any): Promise<{
        status: AuthenticationResultStatus;
    }>;
    static completeSignIn(url: string): Promise<{
        status: AuthenticationResultStatus;
    }>;
    static signOut(state: any): Promise<{
        status: AuthenticationResultStatus;
    }>;
    static completeSignOut(url: string): Promise<{
        status: AuthenticationResultStatus;
    }>;
    private static createUserManager;
}
interface AuthorizeServiceSettings {
    defaultScopes: string[];
}
declare global {
    interface Window {
        AuthenticationService: AuthenticationService;
    }
}
export {};
