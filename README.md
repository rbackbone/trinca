
   C# - SOLID - Projeto implementado com base no curso da Alura
   mas aqui utilizando LiteDB (litedb.org)

    Melhores Práticas
   ----------------------------------------------------------
   - princípio de responsabilidade única
   - princípio do aberto / fechado
   - princípio de inversão de dependência
   - substituição de Liskov (coesão ao implementar abstrações)
   - princípio de segregação de interface


   - O projeto inicalmente usava SQLServer / EntityFramework;
   - Fiz a portabilidade para o LiteDB sem ter que alterar o Controller 
     nem a camada de serviços ; Uma alteração pontual no Modelo.
   
   Obs.: Durante o curso a dependência com o tipo Inteiro foi observada
         mas elencada como uma mudança pouco provável.

         No entanto as chaves primárias auto-incrementadas gerdas pelo Entity 
         são diferentes do tipo gerado pelo LiteDB; Optei por continuar com o 
         tipo inteiro gerando um ID no construtor (para fins didáticos) 

	- Rotas:
       --------------------------------------------------------------

 	Além da aplicação web pode-se utilizar a rota de administração
        
		/leilao

