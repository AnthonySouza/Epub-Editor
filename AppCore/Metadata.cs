﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class Metadata
    {

        private MetadataProperty[] metadataProperties = new MetadataProperty[] {
            new MetadataProperty ("Assunto", "Uma frase arbitrária ou palavra-chave que descreve o assunto em questão. Use múltiplos elementos 'assunto' se for necessário.", "dc:subject", false),
            new MetadataProperty ("Criador", "Representa o autor principal do livro ou publicação", "dc:creator", false),
            new MetadataProperty ("Cobertura", "A extensão ou escopo do conteúdo da publicação", "dc:coverage", false),
            new MetadataProperty ("Contribuinte", "Representa o nome de uma pessoa, organização, etc que teve um papel secundário na criação do conteúdo de uma publicação EPUB. A propriedade 'Papel' pode ser conectada ao elemento para indicar a função que o criador teve na criação do conteúdo", "dc:contributor", false),
            new MetadataProperty ("Criador", "Representa o nome de uma pessoa, organização, etc responsável pela criação do conteúdo de uma publicação EPUB. A propriedade 'Papel' pode ser conectada ao elemento para indicar a função que o criador teve na criação do conteúdo", "dc:creator", false),
            new MetadataProperty ("Data de Criação", "A data de criação", "dcterms:created", false),
            new MetadataProperty ("Data de Modificação", "A data de Modificação", "dcterms:modified", false),
            new MetadataProperty ("Data de Publicação", "A data de publicação do Ebook", "dc:date", false),
            new MetadataProperty ("Descrição", "Descrição do conteúdo da publicação", "dc:description", false),
            new MetadataProperty ("Direitos Autorais", "Informações sobre os direitos pela ou sobre a publicação. Informações de direito normalmente englobam Direitos de Propriedade Intelectual (IPR), Direitos Autorais, e vários Direitos de Propriedade. Se os elementos Direitos estiver ausente, nada se deve presumir sobre quaisquer direitos pela ou sobre a publicação.", "dc:rights", false),
            new MetadataProperty ("Editor", "Uma entidade responsável por tornar a publicação disponível", "dc:publisher", false),
            new MetadataProperty ("Elemento Customizado", "Um elemento de metadados vazio que você pode modificar", "dc:custom", false),
            new MetadataProperty ("Fonte", "Indica o(s) recurso(s) relacionado(s) de que esta publicação EPUB é derivada.", "dc:source", false),
            new MetadataProperty ("Formato", "O tipo de meio ou dimensões da publicação. A melhor prática é usar um valor de um vocabulário controlado (por exemplo, tipos de meio MIME).", "dc:format", false),
            new MetadataProperty ("Identificador: ASIN", "Um Número de Identificação Padrão Amazon associado a esta publicação.", "dc:identifier[urn:AMAZON]", false),
            new MetadataProperty ("Identificador: Customizado", "Um identificador customizado baseado em um esquema específico", "dc:identifier-custom", false),
            new MetadataProperty ("Identificador: DOI", "Identificação Digital de Objeto associada a esta publicação.", "dc:identifier[urn:doi]", false),
            new MetadataProperty ("Identificador: ISBN", "Número de Livro Padrão Internacional (ISBN) associado a esta publicação.", "dc:identifier[urn:isbn]", false),
            new MetadataProperty ("Identificador: ISSN", "Número de Série Padrão Internacional (ISSN) associado a esta publicação", "dc:identifier[urn:issn]", false),
            new MetadataProperty ("Identificador: UUID", "Um Identificador único Universal gerado para esta publicação", "dc:identifier[urn:uuid]", false),
            new MetadataProperty ("Lingua", "Especifica a lingua de publicação. Selecione no menu de seleção.", "dc:language", false),
            new MetadataProperty ("Meta Elemento (primário)", "Um elemento de metadados primário vazio que se pode modificar.", "[name]", false),
            new MetadataProperty ("Pertence a uma Coleção", "Identifica o nome da coleção ao qual a Publicação EPUB pertença. Uma Publicação EPUB pode pertencer a uma ou mais coleções.", "[belongs-to-collection]", false),
            new MetadataProperty ("Relacionado a", "Uma referência a um recurso relacionado. A melhor prática recomendada é identificar o recurso referenciado por meio de um número ou sequência em conformidade com um sistema de identificação formal.", "dc:relation", false),
            new MetadataProperty ("Tipo", "Usado para indicar que uma publicação EPUB determinada é de um tipo especializado.", "dc:type", false),
            new MetadataProperty ("Titulo", "Um título da publicação.  Uma publiação pode ter apenas um título principal, mas pode ter vários outros tipos de título. Estes podem incluir tipos principal, subtítulo, abreviado, edição e título expandido.", "dc:title", false),
            new MetadataProperty ("Identificador", "", "dc:identifier[urn:uuid]", false)
        };


        public Metadata() 
        { 
            
        }

        public MetadataProperty[] MetadataProperties { get => metadataProperties; set => metadataProperties = value; }
    }
}
