using FrameworkGamificacaoClasses;

namespace Ludus.Test;

public class TeacherTest
{
    [Fact]
    public void InstanciedTeacherShouldHaveNullToken()
    {
        var teacher = new Professor(true, "Root", "root", "root@root.com", "123");
        Assert.Null(teacher.Token);
    }
}