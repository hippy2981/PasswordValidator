PasswordValidator
=================

A maintainable and flexible password validator. 


####How it works:

The `PasswordValidator` class contains two regex lists, one for required rules and other for optional rules with a `minimumOptionalRulesToSatisfy` value. The password should match (or not) all required rules and some of the optional rules. 


####Example:

```c#
IEnumerable<string> errors;
bool isValid = passwordValidator.IsValid("Password", out errors);
// isValid: false
// errors are the regexs not satisfied
// errors: { "\d+ (Numeric)", "[^a-zA-Z\d] (Special)" }
```


####How to change: 

Simply add / remove / move around regexs to the required or optional regex lists. 

You can also specify regexs that the password should NOT match (ex: `Repeating` regex).


####Regexs: 

Required (MUST satisfy):
```c#
Length // 8-127
~Repeating // NO 3 or more identical characters in a row
```
Optional (should satisfy some):
```c#
LowerCase
UpperCase
Numeric
Special
```


####Password guidelines:

- [OWASP](https://www.owasp.org/index.php/Authentication_Cheat_Sheet#Password_Complexity "owasp")
- [Gmail](https://support.google.com/accounts/answer/32040?hl=en "gmail")
- [Apple](http://support.apple.com/kb/HT4232 "apple")  
