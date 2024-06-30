export interface Emprestimo {
    id: number;
    usuarioId: number;
    livroIds: number[];
    dataEmprestimo: string;
    dataDevolucaoPrevista: string;
    dataDevolucaoReal?: string;
    status: string;
  }