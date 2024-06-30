import { Emprestimo } from "./Emprestimo";

export interface Livro {
    id: number;
    titulo: string;
    autor: string;
    isbn: string;
    editora?: string;
    anoPublicacao: number;
    emprestimoId?: number;
    emprestimo?: Emprestimo;
  }