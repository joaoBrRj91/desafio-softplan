using System;
namespace Providers.GitPath.Interface
{
    public interface IGitDiretorioRemotoService
    {
        string ObterUrlGithub();
        string FormatarUrlGithub(string githubRepositorioUrl);
    }
}
