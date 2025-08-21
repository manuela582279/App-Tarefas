using App_Tarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace App_Tarefas.Controllers
{
    public class TarefasController : Controller
    {
        //Lista em memoria(grava as informações apenas quando a apliação esta rodando)
        private static List<Tarefa> _tarefas = new List<Tarefa>();
        private static int _proximoId = 1;
        //GET: Tarefas
        public IActionResult Index()
        {
            return View(_tarefas);// Envia a lista de tarefas como parametro para a pagina Index.
        }
        //GET: Tarefas/Criar
        //GET -> Metodo para "pegar" a pagina e exibir
        public IActionResult Create()
        {
            return View();
        }
        //POST: Tarefas/Criar
        [HttpPost] //Específica que esse metodo responde a requisições POST
        [ValidateAntiForgeryToken] //Protege contra ataques 
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid) //Verifica se os dados enviados são validos
            {
                tarefa.TarefaId = _proximoId++;
                _tarefas.Add(tarefa); //Adiciona a nova tarefa a lista
                return RedirectToAction("Index"); //Redireciona para a ação Index
            }
            return View(tarefa); //Se os dados não forem validos, retorna a mesma view com os dados preenchidos
        }

        public IActionResult Edit(int id)
        {
            //var tarefa = _tarefas[id]; //Trabalhando com lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);

        }

        //POST: Tarefas/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tarefa tarefaAtualizada)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);

            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Descricao = tarefaAtualizada.Descricao;
            tarefa.Concluida = tarefaAtualizada.Concluida;

            return RedirectToAction("Index");

        }
        //GET: Tarefas/Edit/1
        public IActionResult Details(int id)
        {
            //var tarefa = _tarefas[id]; //Trabalhando com lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);


        }
        //GET: Tarefas/Edit/1
        public IActionResult Delete(int id)
        {
            //var tarefa = _tarefas[id]; //Trabalhando com lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);

        }
        //Post: Tarefas/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa != null)
            {
                _tarefas.Remove(tarefa); //Remove a tarefa da lista
            }
            return RedirectToAction("Index");


        }
    }
}

