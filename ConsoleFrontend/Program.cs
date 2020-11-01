using Application;
using Application.Accounts.Claims.Commands.AddClaim;
using Application.Accounts.Claims.Commands.RemoveClaim;
using Application.Accounts.Claims.Commands.UpdateClaimValue;
using Application.Accounts.Claims.Queries.GetAllClaims;
using Application.Accounts.Commands.ChangeUsername;
using Application.Accounts.Commands.CreateAccount;
using Application.Accounts.Commands.DeleteAccount;
using Application.Accounts.Emails.Commands.AddEmailAddress;
using Application.Accounts.Emails.Commands.RemoveEmailAddress;
using Application.Accounts.Emails.Commands.SetPrimaryEmail;
using Application.Accounts.Emails.Commands.TryToVerifyEmailAddress;
using Application.Accounts.Emails.Commands.VerifyEmailAddress;
using Application.Accounts.Emails.Queries.GetAllEmailAddresses;
using Application.Accounts.Emails.Queries.GetPrimaryEmailAddress;
using Application.Accounts.Password.Commands.RequestPasswordReset;
using Application.Accounts.Password.Commands.ResetPassword;
using Application.Accounts.Queries.GetAccountById;
using Application.Accounts.Queries.GetAllAccounts;
using Application.Authentication.Commands.Logout;
using Application.Authentication.Queries.AuthenticateToken;
using Application.Authentication.Queries.PasswordLogin;
using Domain.Entities;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleFrontend
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //use case checklist:
            /*
             * create account[v]
             * change username[v]
             * delete account[v]
             * get account by id[v]
             * get all accounts[v]
             * add email[v]
             * set primary email[v]
             * get primary email[v]
             * try to verify email[v]
             * verify email[v]
             * remove email[v]
             * list emails[v]
             * request password reset[v]
             * reset password[v]
             * login[v]
             * authenticate auth token[v]
             * logout
             * add claim[v]
             * remove claim[v]
             * update claim value[v]
             * get all claims[v]
             * get claim value[v]
            */

            Console.WriteLine("Hello World!");

            var app = new Bootstrapper();
            var mediator = app.Mediator;

            //create account
            await mediator.Send(new CreateAccountCommand() { Username = "lorem", Password = "ipsum", EmailAddress = "lorem@ipsum.com" });
            await mediator.Send(new CreateAccountCommand() { Username = "dolor", Password = "sitamet", EmailAddress = "dolor@sitamet.com" });

            //login
            var authDto = await mediator.Send(new PasswordLoginQuery() { Username = "lorem", Password = "ipsum" });
            Console.WriteLine($"[authDto] authToken={authDto.AuthToken}");
            
            //authenticate auth token
            var account1 = await mediator.Send(new AuthenticateTokenQuery() { AuthToken = authDto.AuthToken });
            
            //update username
            await mediator.Send(new UpdateUsernameCommand() { Id = account1.AccountId, NewUsername = "lorem2" });
            var renamedAccount = await mediator.Send(new AuthenticateTokenQuery() { AuthToken = authDto.AuthToken });
            Console.WriteLine($"[renamedAccount] newUsername={renamedAccount.Username}");

            //get all accounts
            var accountslist = await mediator.Send(new GetAllAccountsQuery() { });
            Console.WriteLine($"[accounts]:");
            accountslist.ForEach(i => Console.WriteLine($"{i.AccountId}:{i.Username}"));

            //get account by id
            var account1ById = await mediator.Send(new GetAccountByIdQuery() { Id = accountslist[0].AccountId });
            Console.WriteLine($"[accountById] {account1ById.AccountId}:{account1ById.Username}");

            //add email
            await mediator.Send(new AddEmailAddressCommand() { AccountId = account1.AccountId, EmailAddress = "lorem2@ipsum.com" });

            //try to verify email
            await mediator.Send(new SendEmailVerificationMessageCommand() { AccountId = account1.AccountId, EmailAddress = "lorem2@ipsum.com" });

            //verify email
            //var emailVerifToken = Console.ReadLine();
            //await mediator.Send(new VerifyEmailAddressCommand() { VerificationCode = emailVerifToken });

            //get primary email
            var primaryEmail = await mediator.Send(new GetPrimaryEmailAddressQuery() { AccountId = account1.AccountId });
            Console.WriteLine($"[primary email] address={primaryEmail.EmailAddress}");

            //set primary email
            await mediator.Send(new SetPrimaryEmailCommand() { AccountId = account1.AccountId, Email = "lorem2@ipsum.com" });
            var newPrimaryEmail = await mediator.Send(new GetPrimaryEmailAddressQuery() { AccountId = account1.AccountId });
            Console.WriteLine($"[new primary email] address={newPrimaryEmail.EmailAddress}");

            //get all emails
            var allemails = await mediator.Send(new GetAllEmailAddressesQuery() { AccountId = account1.AccountId });
            allemails.ForEach(i => Console.WriteLine($"[email item] address={i.EmailAddress}; verified={i.IsVerified}"));

            //remove email
            await mediator.Send(new RemoveEmailAddressCommand() { AccountId = account1.AccountId, EmailAddress = "lorem@ipsum.com" });
            allemails = await mediator.Send(new GetAllEmailAddressesQuery() { AccountId = account1.AccountId });
            allemails.ForEach(i => Console.WriteLine($"[email item after deletion] address={i.EmailAddress}; verified={i.IsVerified}"));

            //delete account
            await mediator.Send(new DeleteAccountCommand() { Id = accountslist[1].AccountId });
            var accountsafterdelete = await mediator.Send(new GetAllAccountsQuery() { });
            accountsafterdelete.ForEach(i => Console.WriteLine($"[accounts after deletion] username={i.Username}; id={i.AccountId}"));

            //request password reset
            await mediator.Send(new RequestPasswordResetCommand() { AccountId = account1.AccountId });

            //reset password[v]
            //var resetToken = Console.ReadLine();
            //await mediator.Send(new ResetPasswordCommand() { AccountId = account1.AccountId, NewPassword = "ipsum2", ResetToken = resetToken });
            //authDto = await mediator.Send(new PasswordLoginQuery() { Username = "lorem2", Password = "ipsum2" });
            //Console.WriteLine($"[authDto] authToken={authDto.AuthToken}");
            
            //add claim
            await mediator.Send(new AddClaimCommand() { AccountId = account1.AccountId, ClaimName = "Claim1", ClaimValue = "Claim1Value" });
            await mediator.Send(new AddClaimCommand() { AccountId = account1.AccountId, ClaimName = "Claim2", ClaimValue = "Claim2Value" });

            //get all claims
            var claims = await mediator.Send(new GetAllClaimsQuery() { AccountId=account1.AccountId });
            claims.ForEach(i => Console.WriteLine($"[claims] name={i.Name}, value={i.Value}"));

            //change claim value
            await mediator.Send(new UpdateClaimValueCommand() { AccountId = account1.AccountId, ClaimName = "Claim1", ClaimValue = "Claim1ValueUpdate" });

            //remove claim
            await mediator.Send(new RemoveClaimCommand() { AccountId = account1.AccountId, ClaimName = "Claim2" });

            //reread claims
            claims = await mediator.Send(new GetAllClaimsQuery() { AccountId = account1.AccountId });
            claims.ForEach(i => Console.WriteLine($"[new claims] name={i.Name}, value={i.Value}"));

            //log out
            await mediator.Send(new LogoutCommand() { AuthToken = authDto.AuthToken });

            //reverify token
            account1 = await mediator.Send(new AuthenticateTokenQuery() { AuthToken = authDto.AuthToken });

            Console.ReadKey();
        }
    }
}
