using AlcoholViolationManagement.BLL.Services;
using AlcoholViolationManagement.WinForms.Forms;

namespace AlcoholViolationManagement.WinForms.Helpers;

public sealed class AppLifecycleContext : ApplicationContext
{
    private readonly ServiceContainer _services;
    private LoginForm? _loginForm;
    private MainForm? _mainForm;
    private bool _switching;

    public AppLifecycleContext(ServiceContainer services)
    {
        _services = services;
        ShowLogin();
    }

    private void ShowLogin()
    {
        _loginForm = new LoginForm();
        _loginForm.LoginSucceeded += (_, _) => ShowMain();
        _loginForm.FormClosed += (_, _) =>
        {
            if (_switching) return;
            if (_mainForm is null) ExitThread();
        };
        _loginForm.Show();
    }

    private void ShowMain()
    {
        _switching = true;

        var login = _loginForm;
        _loginForm = null;

        _mainForm = new MainForm();
        _mainForm.FormClosed += (_, _) =>
        {
            if (_switching) return;
            ExitThread();
        };
        _mainForm.LogoutRequested += (_, _) => BeginLogout();
        _mainForm.Show();

        if (login is not null)
        {
            login.Hide();
            login.Dispose();
        }

        _switching = false;
    }

    private void BeginLogout()
    {
        _switching = true;

        var main = _mainForm;
        _mainForm = null;

        _services.SignOut();

        if (main is not null)
        {
            main.Hide();
            main.Dispose();
        }

        ShowLogin();
        _switching = false;
    }
}
