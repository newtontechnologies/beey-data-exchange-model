using Beey.DataExchangeModel.Auth;


namespace Beey.DataExchangeModel.Projects;

public class ProjectAccessDto
{
    public int Id { get; set; }
    public DateTimeOffset? Created { get; set; }
    public DateTimeOffset? Updated { get; set; }

    public int UserId { get; set; }
    public UserDto? User { get; set; }
    public int ProjectId { get; set; }
    public ProjectDto Project { get; set; }

    public string CustomPath { get; set; }
}

public class ProjectAccessUpdateModel
{
    public string CustomPath { get; set; }
}
