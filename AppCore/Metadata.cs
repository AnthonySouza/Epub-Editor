using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public static class Metadata
    {

        private static MetadataItem[] metadataItem = new MetadataItem[] {
            new MetadataItem ("Assunto", "Uma frase arbitrária ou palavra-chave que descreve o assunto em questão. Use múltiplos elementos 'assunto' se for necessário.", "dc:subject", false),
            new MetadataItem ("Criador", "Representa o autor principal do livro ou publicação", "dc:creator", false),
            new MetadataItem ("Cobertura", "A extensão ou escopo do conteúdo da publicação", "dc:coverage", false),
            new MetadataItem ("Contribuinte", "Representa o nome de uma pessoa, organização, etc que teve um papel secundário na criação do conteúdo de uma publicação EPUB. A propriedade 'Papel' pode ser conectada ao elemento para indicar a função que o criador teve na criação do conteúdo", "dc:contributor", false),
            new MetadataItem ("Criador", "Representa o nome de uma pessoa, organização, etc responsável pela criação do conteúdo de uma publicação EPUB. A propriedade 'Papel' pode ser conectada ao elemento para indicar a função que o criador teve na criação do conteúdo", "dc:creator", false),
            new MetadataItem ("Data de Criação", "A data de criação", "dcterms:created", false),
            new MetadataItem ("Data de Modificação", "A data de Modificação", "dcterms:modified", false),
            new MetadataItem ("Data de Publicação", "A data de publicação do Ebook", "dc:date", false),
            new MetadataItem ("Descrição", "Descrição do conteúdo da publicação", "dc:description", false),
            new MetadataItem ("Direitos Autorais", "Informações sobre os direitos pela ou sobre a publicação. Informações de direito normalmente englobam Direitos de Propriedade Intelectual (IPR), Direitos Autorais, e vários Direitos de Propriedade. Se os elementos Direitos estiver ausente, nada se deve presumir sobre quaisquer direitos pela ou sobre a publicação.", "dc:rights", false),
            new MetadataItem ("Editor", "Uma entidade responsável por tornar a publicação disponível", "dc:publisher", false),
            new MetadataItem ("Elemento Customizado", "Um elemento de metadados vazio que você pode modificar", "dc:custom", false),
            new MetadataItem ("Fonte", "Indica o(s) recurso(s) relacionado(s) de que esta publicação EPUB é derivada.", "dc:source", false),
            new MetadataItem ("Formato", "O tipo de meio ou dimensões da publicação. A melhor prática é usar um valor de um vocabulário controlado (por exemplo, tipos de meio MIME).", "dc:format", false),
            new MetadataItem ("Identificador: ASIN", "Um Número de Identificação Padrão Amazon associado a esta publicação.", "dc:identifier[urn:AMAZON]", false),
            new MetadataItem ("Identificador: Customizado", "Um identificador customizado baseado em um esquema específico", "dc:identifier-custom", false),
            new MetadataItem ("Identificador: DOI", "Identificação Digital de Objeto associada a esta publicação.", "dc:identifier[urn:doi]", false),
            new MetadataItem ("Identificador: ISBN", "Número de Livro Padrão Internacional (ISBN) associado a esta publicação.", "dc:identifier[urn:isbn]", false),
            new MetadataItem ("Identificador: ISSN", "Número de Série Padrão Internacional (ISSN) associado a esta publicação", "dc:identifier[urn:issn]", false),
            new MetadataItem ("Identificador: UUID", "Um Identificador único Universal gerado para esta publicação", "dc:identifier[urn:uuid]", false),
            new MetadataItem ("Lingua", "Especifica a lingua de publicação. Selecione no menu de seleção.", "dc:language", false),
            new MetadataItem ("Meta Elemento (primário)", "Um elemento de metadados primário vazio que se pode modificar.", "[name]", false),
            new MetadataItem ("Pertence a uma Coleção", "Identifica o nome da coleção ao qual a Publicação EPUB pertença. Uma Publicação EPUB pode pertencer a uma ou mais coleções.", "[belongs-to-collection]", false),
            new MetadataItem ("Relacionado a", "Uma referência a um recurso relacionado. A melhor prática recomendada é identificar o recurso referenciado por meio de um número ou sequência em conformidade com um sistema de identificação formal.", "dc:relation", false),
            new MetadataItem ("Tipo", "Usado para indicar que uma publicação EPUB determinada é de um tipo especializado.", "dc:type", false),
            new MetadataItem ("Titulo", "Um título da publicação.  Uma publiação pode ter apenas um título principal, mas pode ter vários outros tipos de título. Estes podem incluir tipos principal, subtítulo, abreviado, edição e título expandido.", "dc:title", false),
            new MetadataItem ("Identificador", "", "dc:identifier[urn:uuid]", false)
        };

        private static MetadataProperty[] metadataProperty = new MetadataProperty[]
        {
            new MetadataProperty ("Arquivo Como", "Fornece uma forma normalizada da propriedade associada para classificação. Tipicamente usado com nomes de autor, criador e colaboraador.", "", false),
            new MetadataProperty ("Atributo Customizado", "Um atributo metadados vazio modificável", "", false),
            new MetadataProperty ("Atributo Identificador", "Identificador opcional, normalmente curto e único usado como atributo no pacote (opf) do documento.", "", false),
            new MetadataProperty ("Esquema", "Este atributo normalmente é adicionado a dc:identificador para indicar o tipo de identificador em uso> DOI, ISBN, ISSN, UUID ou AMAZON.", "", false),
            new MetadataProperty ("Esquema personalizado", "Este atributo normalmente é adicionado para dc:identificador para indicar que um identificador de esquema personalizado está sendo usado.", "", false),
            new MetadataProperty ("Evento", "Esse atributo geralmente é adicionado aos elementos dc:date para especificar o tipo de data: publicação, criação ou modificação.", "", false),
            new MetadataProperty ("Linguagem XML", "Atributo especificador de linguagem, opcional. Usa os mesmos códigos que dc:lingua. Não deve ser usado com os elementos metadados dc:lingua, dc:data ou dc:identificador.", "", false),
            new MetadataProperty ("Papel", "Descreve a natureza do trabalho executado por um criador ou colaborador (por exemplo, que a pessoa é autor ou editor de um trabalho). Tipicamente usado com o esquema marc:relators para um vocabulário controlado.", "", false)
        };

        public static MetadataItem[] MetadataItem { get => metadataItem; set => metadataItem = value; }

        //public static MetadataProperty[] MetadataProperty { get => metadataProperty; set => metadataProperty = value; }
    }
}
