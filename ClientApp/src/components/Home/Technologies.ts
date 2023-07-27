export interface Technology {
  /** The name of the technology. */
  name: string;
  /** A description of the technology. */
  description: string;
  /** A link to the technology's website or otherwise existant documentation. */
  link: string;
}

export const technologies: Technology[] = [
  {
    name: 'ASP.NET Core',
    description: 'A cross-platform and open-source web framework for building modern cloud-based web applications on more than just Windows.',
    link: 'https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0'
  },
  {
    name: 'React',
    description: 'A JavaScript library for building user interfaces with reusable components and a virtual DOM.',
    link: 'https://react.dev'
  },
  {
    name: 'Bootstrap',
    description: 'A free and open-source CSS framework directed at responsive, mobile-first front-end web development.',
    link: 'https://getbootstrap.com'
  },
  {
    name: 'Reactstrap',
    description: 'A library of React components built with Bootstrap.',
    link: 'https://reactstrap.github.io/?path=/docs/home-installation--page'
  },
  {
    name: 'TypeScript',
    description: 'A typed superset of JavaScript that compiles to plain JavaScript, allowing for the use of modern JavaScript features and improved tooling.',
    link: 'https://www.typescriptlang.org'
  }
];
