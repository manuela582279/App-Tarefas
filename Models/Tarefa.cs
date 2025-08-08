namespace App_Tarefas.Models
{
    public class Tarefa
    {
        //Nome da chave primaria deve ser Nome da classe + "Id"
        public int TarefaId { get; set; } //Id é a chave primaria
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }

    }
}
