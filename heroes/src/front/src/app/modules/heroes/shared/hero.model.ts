import {Deserializable} from '../../../shared/interfaces/deserializable.interface';

export class Hero implements Deserializable {
  id: string;
  name: string;
  alterEgo: string;
  likes: number;
  default: boolean;
  avatarUrl: string;
  avatarThumbnailUrl: string;

  constructor(hero: any = {}) {
    this.id = hero.id;
    this.name = hero.name || '';
    this.alterEgo = hero.alterEgo || '';
    this.likes = hero.likes || 0;
    this.default = hero.default || false;
    this.avatarUrl = hero.avatarUrl || '';
    this.avatarThumbnailUrl = hero.avatarThumbnailUrl || '';

    // console.log('avatarUrl=' + this.avatarUrl);
    // console.log('avatarThumbnailUrl=' + this.avatarThumbnailUrl);
    console.log(JSON.stringify(this));
  }

  like() {
    this.likes += 1;
    localStorage.setItem('votes', '' + (Number(localStorage.getItem('votes')) + 1));
  }

  deserialize(input: any) {
    Object.assign(this, input);
    return this;
  }
}
