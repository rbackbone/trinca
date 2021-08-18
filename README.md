
   
    --------------------------------------------------------------
	- Rotas:                                Verbos
    --------------------------------------------------------------

        /api/churras                        GET, POST, PUT
        /api/churras/{id}                   GET, POST, PUT, DELETE
        
    {  
	    "descricao":"Churras de fim da pandemia",
	    "observacoes":"Pode levar o cachorrro",
	    "data":"2012-04-23T18:25:43.511Z",
	    "valorSugerido1":10,
	    "valorSugerido2":20
    }

        /api/churras/incluirParticipante    POST
        /api/churras/excluirParticipante    DELETE

    {
	    "churrasId":5,
        "participanteId":3,
        "valorContribuicao":15
    }
        /api/churras/{id}/listarParticipantes   GET
        /api/churras/{id}/listarPovoDeFora      GET
 	

